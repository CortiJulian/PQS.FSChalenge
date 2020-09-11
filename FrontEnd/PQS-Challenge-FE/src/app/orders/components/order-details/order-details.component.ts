import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { OrdersService } from '../../services/orders.service';
import { Order } from '../../services/models/orders.model';
import { switchMap } from 'rxjs/operators';

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
  order: Order;

  ngOnInit() {
      this.orderId = Number.parseInt(this.route.snapshot.paramMap.get('id'), 10);
      this.orderService.getOrderById(this.orderId).subscribe(result => {
        this.order = result;
      });
  }

  approveOrder() {
    this.orderService.approveOrder(this.orderId).pipe(
      switchMap(res => this.orderService.getOrderById(this.orderId))
    ).subscribe(result => {
      this.order = result;
    },
    error => {
      console.error(error);
    })
  }

  rejectOrder() {
    this.orderService.rejectOrder(this.orderId).pipe(
      switchMap(res => this.orderService.getOrderById(this.orderId))
    ).subscribe(result => {
      this.order = result;
    },
    error => {
      console.error(error);
    })
  }

  getOrderTotalAmount(): number {
    const amount = this.order.OrderItems.map(item => item.Quantity * item.UnitPrice).reduce((sum, current) => sum + current, 0);
    return amount;
  }

}
