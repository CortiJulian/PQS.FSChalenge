import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(protected http: HttpClient) { }

  getOrderById(orderId: number) {
    return this.http.get('http://localhost:53634/api/Orders/GetOrderById/' + orderId);
  }

  getOrders(status: string) {
    return this.http.get('http://localhost:53634/api/Orders/' + status);
  }
}
