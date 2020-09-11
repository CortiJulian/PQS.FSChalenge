import { Order, OrderInfo, OrderItem } from '../models/orders.model';
import { Observable } from 'rxjs';

export class OrderBuilder {
    model: Order;

    constructor(rawData: any) {
        this.model = new Order(rawData.orderId, rawData.orderDescription, rawData.orderStatus, rawData.createdOn, rawData.authDate, rawData.orderItems);
    }

    getModel(): Order {
        return this.model;
    }
}

export class OrderInfoBuilder {
    model: Array<OrderInfo>;

    constructor(rawData: any) {
        this.model = rawData.map(result => {
            return new OrderInfo(result.orderId, result.orderDescription, result.orderStatus, result.qitems, result.total, result.createdOn, result.authDate);
        });
    }

    getModel(): Array<OrderInfo> {
        return this.model;
    }
}