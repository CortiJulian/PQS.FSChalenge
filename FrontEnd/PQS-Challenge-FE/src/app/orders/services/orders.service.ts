import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(protected http: HttpClient) { }

  getOrderById(orderId: number) {
    return this.http.get('http://localhost:53634/api/Orders/' + orderId);
  }

  getOrders(status: string) {
    return this.http.get('http://localhost:53634/api/Orders/' + status);
  }

  approveOrder(id: number) {
    return this.http.post('http://localhost:53634/api/Orders/' + id, '');
  }

  rejectOrder(id: number) {
    return this.http.delete('http://localhost:53634/api/Orders/' + id);
  }
}
