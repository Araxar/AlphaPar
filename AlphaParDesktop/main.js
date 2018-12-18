//handle setupevents as quickly as possible
 const setupEvents = require('./installers/setupEvents')
 if (setupEvents.handleSquirrelEvent()) {
    // squirrel event handled and app will exit in 1000ms, so don't do anything else
    return;
 }

const electron = require('electron')
// Module to control application life.
const app = electron.app
const {ipcMain} = require('electron')
var path = require('path')

const electron = require('electron');

const { app, BrowserWindow } = require('electron');
let win = null;

function createWindow () {
    // Create window
    win = new BrowserWindow({
        width: 1170, 
        height: 700,
        show: false
    });

    // Load AlphaPar ERP locally
    win.loadURL('http://localhost/');
    win.once('ready-to-show', () => {
        win.show()
      })

    win.on(closed, () => {
        win = null
    })
}

app.on('ready', createWindow);