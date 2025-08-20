import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../Core/services/account-service';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastService } from '../../Core/services/toast-service';

@Component({
  selector: 'app-nav',
  imports: [FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrl: './nav.css'
})
export class Nav {
  protected accountService = inject(AccountService);
  private router = inject(Router);  
  protected creds: any = {};
  private toast = inject(ToastService);

  login() {
    this.accountService.login(this.creds).subscribe({
      next: () => {
        
        this.toast.success('Login successful');
        this.creds = {};
        this.router.navigateByUrl('/members');
      },
      error: error => {
        this.toast.error(error.error);
      }
    });
  }

  logout(){
   this.accountService.logout();
   this.router.navigateByUrl('/');
  }
}
