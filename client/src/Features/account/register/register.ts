import { Component, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RegisterCreds, User } from '../../../types/user';
import { AccountService } from '../../../Core/services/account-service';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
 private accountService = inject(AccountService); 

  cancelRegister = output<boolean>()

  protected creds = {} as RegisterCreds;

  register() {
    this.accountService.register(this.creds).subscribe({
      next: user => {
        console.log(user);
        this.cancel();
      },
      error: err => {
        console.error(err);
      }
    });
  }

  cancel(){
    this.cancelRegister.emit(false);
  }
}
