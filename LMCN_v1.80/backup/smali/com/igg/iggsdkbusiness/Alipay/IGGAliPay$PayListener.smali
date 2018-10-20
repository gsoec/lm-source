.class public interface abstract Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;
.super Ljava/lang/Object;
.source "IGGAliPay.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "PayListener"
.end annotation


# virtual methods
.method public abstract onError()V
.end method

.method public abstract onSuccess(Lcom/igg/iggsdkbusiness/Alipay/PayResult;)V
.end method

.method public abstract onWaitResult()V
.end method
