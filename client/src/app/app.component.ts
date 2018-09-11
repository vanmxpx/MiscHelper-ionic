import { Component, OnInit } from '@angular/core';
import { Platform, ToastController } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import * as signalR from "@aspnet/signalr";

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent implements OnInit {
  _hubConnection: signalR.HubConnection;

  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
    private toastController: ToastController
  ) {
    this.initializeApp();
  }

  async presentToast() {
    const toast = await this.toastController.create({
      message: 'Your settings have been saved.',
      duration: 2000
    });
    toast.present();
  }

  async presentToastWithOptions(msg: string) {
    const toast = await this.toastController.create({
      message: 'New Message: ${msg}',
      showCloseButton: true,
      position: 'top',
      closeButtonText: 'Done',
      duration: 2000
    });
    toast.present();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    });
  }

  ngOnInit(): void {
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5000/notify')
      .build();

    this._hubConnection
    .start()      
    .then(() => console.log('Connection started!'))
    .catch(err => { 
      console.log('Error while establishing connection :('); 
      console.log(err);
    });

    this._hubConnection.on('BroadcastMessage', (type: string, payload: string) => {
      this.presentToastWithOptions(payload);
    });
  }
}
