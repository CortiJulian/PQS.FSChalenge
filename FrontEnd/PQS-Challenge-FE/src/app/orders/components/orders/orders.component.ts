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

  pendingApproval = {
      name: 'Pending Approval',
      value: 'pending'
  };

  approved = {
    name: 'Approved',
    value: 'approved'
  };

  rejected = {
    name: 'Rejected',
    value: 'rejected'
  };

  statuses = [this.pendingApproval, this.approved, this.rejected];

  selectedStatus = 'Pending Approval';

  ngOnInit(): void {
    this.ordersService.getOrders(this.pendingApproval.value).subscribe(result => {
      this.orders = result;
    },
    error => {
      console.error(error);
    });
  }

  setStatus(status) {
    this.selectedStatus = status.name;
    this.ordersService.getOrders(status.value).subscribe(result => {
      this.orders = result;
    },
    error => {
      console.error(error);
    });
  }

}
