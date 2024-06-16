const { app, BrowserWindow } = require('electron')
const path = require('path');
const url = require('url');

module.exports  = {
  publicPath: process.env.NODE_ENV  ===  'production'  ?  './'  :  '/',
  outputDir: "./out/",
  indexPath: path.resolve(__dirname, "out", "index.html")
}

function createWindow () {
  const win = new BrowserWindow({
    title: 'Asparagus App',
    width: 800,
    height: 600,
  })

  win.loadURL(url.format({
    pathname: path.join(__dirname, 'index.html'),
    protocol: 'file:',
    slashes: true
  }));
}

app.whenReady().then(() => {
  createWindow()

  app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) {
      createWindow()
    }
  })
})

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit()
  }
})