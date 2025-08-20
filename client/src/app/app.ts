import { Component, signal, inject, OnInit } from '@angular/core';
import { Nav } from '../Layout/nav/nav';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [Nav, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App implements OnInit {
  protected router = inject(Router);

  async ngOnInit(): Promise<void> {}
}
