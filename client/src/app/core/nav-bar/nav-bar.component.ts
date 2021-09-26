import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',//app é um prefixo que é gerado automaticamente
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
