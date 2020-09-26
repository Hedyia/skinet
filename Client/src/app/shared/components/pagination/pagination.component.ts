import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss'],
})
export class PaginationComponent implements OnInit {
  @Input() totalCount: number;
  @Input() pageSize: number;
  // tslint:disable-next-line:no-output-on-prefix
  @Output() pageChanged = new EventEmitter<number>();
  constructor() {}

  ngOnInit(): void {}

  // tslint:disable-next-line:typedef
  onPageChanged(event) {
    this.pageChanged.emit(event.page);
  }
}
