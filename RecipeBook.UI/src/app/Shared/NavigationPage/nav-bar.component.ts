import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {
  collapseNavMenu: boolean = true;

  NavMenuCssClass: string | null = "";

  ToggleNavMenu() {
    this.collapseNavMenu = !this.collapseNavMenu;
    this.NavMenuCssClass = this.collapseNavMenu ? "collapse" : null;
  }
 
}
