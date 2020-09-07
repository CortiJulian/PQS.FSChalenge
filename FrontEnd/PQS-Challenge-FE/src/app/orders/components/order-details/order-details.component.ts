import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
  ) {}

  orderId: number;

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.orderId = params['orderId'];
    });
  }

}
