.class public interface abstract Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;
.super Ljava/lang/Object;
.source "IGGPaymentItemsComposer.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "IGGPaymentCardsComposedListener"
.end annotation


# virtual methods
.method public abstract onPaymentCardsComposed(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
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
