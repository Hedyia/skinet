import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-pagination-header',
  templateUrl: './pagination-header.component.html',
  styleUrls: ['./pagination-header.component.scss'],
})
export class PaginationHeaderComponent implements OnInit {
  @Input() totalCount = 0;
  @Input() pageIndex = 0;
  @Input() pageSize = 0;
  constructor() {}

  ngOnInit(): void {}
}
