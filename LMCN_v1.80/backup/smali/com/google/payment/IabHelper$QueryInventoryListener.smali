.class public interface abstract Lcom/google/payment/IabHelper$QueryInventoryListener;
.super Ljava/lang/Object;
.source "IabHelper.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/payment/IabHelper;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "QueryInventoryListener"
.end annotation


# virtual methods
.method public abstract onQueryInventoryFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
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
