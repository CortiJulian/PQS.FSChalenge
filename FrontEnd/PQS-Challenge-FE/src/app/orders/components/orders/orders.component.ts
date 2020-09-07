import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../../services/orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  constructor(private ordersService: OrdersService) { }

  orders: any;

  ngOnInit(): void {
    this.ordersService.getOrders().subscribe(result => {
      console.log('results', result);
      this.orders = result;
    },
    error => {
      console.error(error);
    })
  }

}
