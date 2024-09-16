import express from "express";
import { Router } from "express";
import path from "path";

const router = Router();

router.get("/", (req, res) => {
    const homeFile = path.join(__dirname, "..", "..", "./public/index.html");
    res.sendFile(homeFile);
});

export default router;