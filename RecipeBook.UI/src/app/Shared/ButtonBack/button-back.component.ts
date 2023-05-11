import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-button-back',
  templateUrl: './button-back.component.html',
  styleUrls: ['./button-back.component.css']
})
export class ButtonBackComponent {
  @Input() Addlink: string = "";

  constructor(private route: Router) { }

  Return() {
    this.route.navigate([this.Addlink])
  }


}
