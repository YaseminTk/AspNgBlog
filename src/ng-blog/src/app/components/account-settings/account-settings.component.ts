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
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-account-settings',
  standalone: true,
  imports: [CommonModule, MatButtonModule, MatFormFieldModule, MatIconModule, MatInputModule, MatGridListModule, MatDividerModule, FormsModule, ReactiveFormsModule, HttpClientModule, MatProgressSpinnerModule],
  templateUrl: './account-settings.component.html',
  styleUrl: './account-settings.component.scss'
})
export class AccountSettingsComponent {
  hide = signal(true);

  readonly fb: FormBuilder = inject(FormBuilder);

  form: FormGroup = this.fb.group({
    userName: ['', Validators.required],
    fullName: ['', Validators.required],
    password1: ['', Validators.required],
    password2: ['', Validators.required]
  });

  readonly authService: AuthService = inject(AuthService);

  readonly userService: UserService = inject(UserService);

  public dialog: MatDialog = inject(MatDialog);

  loading: boolean = false;

  private currentUser: any;

  private _snackBar = inject(MatSnackBar);

  async ngOnInit(): Promise<void> {
    const user = await this.userService.getCurrentAsync();
    this.currentUser = user;
    this.reset()
  }

  reset() {
    this.form.patchValue({
      userName: this.currentUser.userName,
      fullName: this.currentUser.fullName,
      password1: '',
      password2: ''
    });
  }

  update() {
    if (this.form.valid || true) {
      this.loading = true;

      const newUser = {
        id: this.currentUser.id,
        userName: this.form.get("userName")?.value,
        fullName: this.form.get("fullName")?.value,
      }

      this.userService.update(newUser).subscribe({
        next: res => {
          this.loading = false;
        },
        error: err => {
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

  pwClickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }
}