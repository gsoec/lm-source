.class public Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;
.super Ljava/lang/Object;
.source "IGGPaymentItemsComposer.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;
    }
.end annotation


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGPaymentItemsComposer"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 19
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 20
    return-void
.end method


# virtual methods
.method public compose(Ljava/util/ArrayList;Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;)V
    .locals 2
    .param p2, "listener"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;",
            "Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 23
    .local p1, "items":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    invoke-static {}, Lcom/google/payment/IabHelper;->sharedInstance()Lcom/google/payment/IabHelper;

    move-result-object v0

    new-instance v1, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$1;

    invoke-direct {v1, p0, p2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$1;-><init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;)V

    invoke-virtual {v0, p1, v1}, Lcom/google/payment/IabHelper;->queryInventoryAsync(Ljava/util/ArrayList;Lcom/google/payment/IabHelper$QueryInventoryListener;)V

    .line 29
    return-void
.end method
