.class public interface abstract Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;
.super Ljava/lang/Object;
.source "IGGPaymentService.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/service/IGGPaymentService;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "PaymentItemsListListener"
.end annotation


# virtual methods
.method public abstract onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;)V"
        }
    .end annotation
.end method
