.class public Lcom/facebook/appevents/internal/Constants;
.super Ljava/lang/Object;
.source "Constants.java"


# static fields
.field public static final EVENT_NAME_EVENT_KEY:Ljava/lang/String; = "_eventName"

.field public static final LOG_TIME_APP_EVENT_KEY:Ljava/lang/String; = "_logTime"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 23
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static getDefaultAppEventsSessionTimeoutInSeconds()I
    .locals 1

    .prologue
    .line 28
    const/16 v0, 0x3c

    return v0
.end method
