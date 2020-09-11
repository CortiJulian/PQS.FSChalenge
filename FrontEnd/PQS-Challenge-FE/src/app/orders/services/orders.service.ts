import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { OrderBuilder, OrderInfoBuilder } from './builder/orders.builder';
import { Observable } from 'rxjs';
import { Order } from './models/orders.model';
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(protected http: HttpClient) { }

  getOrderById(orderId: number): Observable<Order> {
    return this.http.get('http://localhost:53634/api/Orders/' + orderId).pipe(
      map(data => {
        const builder = new OrderBuilder(data);
        return builder.getModel();
      })
    );
  }

  getOrders(status: string) {
    return this.http.get('http://localhost:53634/api/Orders/' + status).pipe(
      map(data => {
        const builder = new OrderInfoBuilder(data);
        return builder.getModel();
      })
    );
  }

  approveOrder(id: number) {
    return this.http.post('http://localhost:53634/api/Orders/' + id, '');
  }

  rejectOrder(id: number) {
    return this.http.delete('http://localhost:53634/api/Orders/' + id);
  }
}
