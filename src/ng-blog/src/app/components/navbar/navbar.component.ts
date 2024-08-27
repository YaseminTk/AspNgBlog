import { Component, inject } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component'
@Component({
  selector: 'navbar',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  public dialog: MatDialog = inject(MatDialog);
  dialogConfig: MatDialogConfig = {

  }
  openLogin() {

    this.dialog.open(LoginComponent, this.dialogConfig);
  }
}