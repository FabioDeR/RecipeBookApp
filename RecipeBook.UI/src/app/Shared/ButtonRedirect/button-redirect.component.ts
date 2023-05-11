import { Component, Input } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-button-redirect',
  templateUrl: './button-redirect.component.html',
  styleUrls: ['./button-redirect.component.css']
})
export class ButtonRedirectComponent {

  @Input() Addlink: string = "";

  constructor(private route: Router) { }


  Redirect(): void {
    this.route.navigate([this.Addlink])
  }


}
