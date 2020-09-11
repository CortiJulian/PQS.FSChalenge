export class Order {
    Id: number;
    Description: string;
    StatusNum: number;
    CreatedOn: Date;
    AuthDate: Date;

    OrderItems: OrderItem[];

    constructor (orderId, orderDescription, orderStatus, createdOn, authDate = null, orderItems) {
        this.Id = orderId;
        this.Description = orderDescription;
        this.StatusNum = orderStatus;
        this.CreatedOn = createdOn;
        this.AuthDate = authDate;

        this.OrderItems = orderItems.map(item => {
            return new OrderItem(item.orderItemId, item.orderId, item.itemDescription, item.quantity, item.unitPrice)
        });
    }
}

export class OrderInfo {
    Id: number;
    Description: string;
    StatusNum: number;
    ItemsQuantity: number;
    TotalAmount: number;
    CreatedOn: Date;
    AuthDate: Date;

    constructor (orderId, orderDescription, orderStatus, qItems = null, total = null, createdOn, authDate = null) {
        this.Id = orderId;
        this.Description = orderDescription;
        this.StatusNum = orderStatus;
        this.ItemsQuantity = qItems;
        this.TotalAmount = total;
        this.CreatedOn = createdOn;
        this.AuthDate = authDate;
    }
}

export class OrderItem {
    ItemId: number;
    OrderId: number;
    ItemDescription: string;
    Quantity: number;
    UnitPrice: number;

    constructor (orderItemId, orderId, itemDescription, quantity, unitPrice) {
        this.ItemId = orderItemId;
        this.OrderId = orderId;
        this.ItemDescription = itemDescription;
        this.Quantity = quantity;
        this.UnitPrice = unitPrice;
    }
}