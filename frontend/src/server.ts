import app from "./app";
import express from "express";
import path from "path";

const port = 8024;

app.use(express.static(path.join(__dirname, '..', './public')));

app.listen(port, () => {
    console.log(`\n > Running on http://localhost:${port} \n`);
});