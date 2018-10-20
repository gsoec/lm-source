.class public interface abstract Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;
.super Ljava/lang/Object;
.source "IGGPayment.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/payment/google/IGGPayment;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "IGGPurchaseListener"
.end annotation


# virtual methods
.method public abstract onIGGPurchaseFailed(Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;Lcom/google/payment/Purchase;)V
.end method

.method public abstract onIGGPurchaseFinished(Lcom/google/payment/Purchase;Ljava/lang/Boolean;)V
.end method

.method public abstract onIGGPurchasePreparingFinished(ZLjava/lang/String;)V
.end method

.method public abstract onIGGPurchaseStartingFinished(Z)V
.end method
