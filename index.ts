import * as path from 'path';
import * as express from 'express';
import * as serveIndex from 'serve-index';
import { createServer } from 'http';
import { Server } from 'colyseus';
import { BasicRoom } from "./rooms/Main";

process.on('uncaughtException', function(err) {
    console.log('Caught exception: ' + err);
    console.log(err.stack);
});

var colyseus = require('colyseus');
var express = require('express');
var http = require('http');

var app = express();
var port = Number(process.env.PORT || 2657);
var httpServer = http.createServer(app);

var gameServer = new colyseus.Server({ server: httpServer });
var Arena = require('./rooms/Main');

gameServer.register('Basic', Arena)

gameServer.listen(port);

console.log(`Listening on http://localhost:${ port }`);
