import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(protected http: HttpClient) { }

  getOrderById(orderId: number) {
    return this.http.get('http://localhost:53634/Orders/GetOrderById/' + orderId);
  }

  getOrders() {
    const orderStatusPendingApproval = 0;
    return this.http.get('http://localhost:53634/Orders/GetOrders/0');
  }
}
