.class public Lcom/igg/iggsdkbusiness/GlobalApplication;
.super Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;
.source "GlobalApplication.java"


# static fields
.field private static instance:Lcom/igg/iggsdkbusiness/GlobalApplication;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 11
    invoke-direct {p0}, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;-><init>()V

    return-void
.end method

.method public static getInstance()Lcom/igg/iggsdkbusiness/GlobalApplication;
    .locals 1

    .prologue
    .line 25
    sget-object v0, Lcom/igg/iggsdkbusiness/GlobalApplication;->instance:Lcom/igg/iggsdkbusiness/GlobalApplication;

    return-object v0
.end method

.method public static setInstance(Lcom/igg/iggsdkbusiness/GlobalApplication;)V
    .locals 0
    .param p0, "application"    # Lcom/igg/iggsdkbusiness/GlobalApplication;

    .prologue
    .line 29
    sput-object p0, Lcom/igg/iggsdkbusiness/GlobalApplication;->instance:Lcom/igg/iggsdkbusiness/GlobalApplication;

    .line 30
    return-void
.end method


# virtual methods
.method protected attachBaseContext(Landroid/content/Context;)V
    .locals 0
    .param p1, "base"    # Landroid/content/Context;

    .prologue
    .line 21
    invoke-super {p0, p1}, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->attachBaseContext(Landroid/content/Context;)V

    .line 22
    return-void
.end method

.method public onCreate()V
    .locals 0

    .prologue
    .line 16
    invoke-super {p0}, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->onCreate()V

    .line 17
    return-void
.end method
