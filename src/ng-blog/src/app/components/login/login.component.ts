import { CommonModule } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDividerModule } from '@angular/material/divider';
import { FormBuilder, FormGroup, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service'
import { HttpClientModule } from '@angular/common/http'
import { MatDialog } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, MatButtonModule, MatFormFieldModule, MatIconModule, MatInputModule, MatGridListModule, MatDividerModule, FormsModule, ReactiveFormsModule, HttpClientModule, MatProgressSpinnerModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  hide = signal(true);
  clickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }

  readonly fb: FormBuilder = inject(FormBuilder);
  form!: FormGroup;
  readonly authService: AuthService;
  public dialog: MatDialog = inject(MatDialog);

  loading: boolean = false;

  private _snackBar = inject(MatSnackBar);

  constructor() {
    this.authService = inject(AuthService)
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.form.valid) {
      this.loading = true;
      this.authService.login({ userName: this.form.value.userName, password: this.form.value.password }).subscribe({
        next: res => {
          this.dialog.closeAll()
        },
        error: err => {
          if(err.status === 401)
            this._snackBar.open("The username or password you entered is incorrect.", "Ok")
          else
          this._snackBar.open("An internal service error has occurred. Please try again later or contact support.", "Ok")
          this.loading = false;
        },
        complete: () => {
          this.loading = false;
        },
      });
    } else {
      this._snackBar.open("Username or password is missing.", "Ok")
    }
  }
}