import express from "express";

import router from "./routes/homeRoute";

const app = express();

app.get("/", router);

export default app;