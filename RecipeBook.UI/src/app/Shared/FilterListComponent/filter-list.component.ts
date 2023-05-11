import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { Utils } from '../Utils/Utils';

@Component({
  selector: 'app-filter-list',
  templateUrl: './filter-list.component.html',
  styleUrls: ['./filter-list.component.css']
})
export class FilterListComponent implements OnChanges {
  
  @Input() normalList: any;
  filteredList: any;
  private _listFilter: string = "";
  @Output() filtered: EventEmitter<any> = new EventEmitter<any>();


  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {    
    this._listFilter = value;   
    this.filtered.emit(this.performsFilter(this.listFilter))
  }

  ngOnChanges(): void {  
    this.filteredList = this.normalList;
  }

  performsFilter(filterstring: string): any {
    return Utils.FilterList(filterstring, this.filteredList);
  }
  



}
