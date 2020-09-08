import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { OrdersService } from '../../services/orders.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private orderService: OrdersService
  ) {}

  orderId: number;
  order: any;

  ngOnInit() {
      this.orderId = Number.parseInt(this.route.snapshot.paramMap.get('id'), 10);
      this.orderService.getOrderById(this.orderId).subscribe(result => {
        this.order = result;
      });
  }

  approveOrder() {
    this.orderService.approveOrder(this.orderId).subscribe(result => {
      console.log('result:', result);
    },
    error => {
      console.error(error);
    })
  }

  rejectOrder() {
    this.orderService.rejectOrder(this.orderId).subscribe(result => {
      console.log('result:', result);
    },
    error => {
      console.error(error);
    })
  }

}
