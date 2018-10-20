.class Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$1;
.super Ljava/lang/Object;
.source "IGGPaymentItemsComposer.java"

# interfaces
.implements Lcom/google/payment/IabHelper$QueryInventoryListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;->compose(Ljava/util/ArrayList;Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;

.field final synthetic val$listener:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;

    .prologue
    .line 23
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;

    iput-object p2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$1;->val$listener:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onQueryInventoryFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
    .locals 1
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
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

    .prologue
    .line 26
    .local p2, "items":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$1;->val$listener:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;

    invoke-interface {v0, p1, p2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;->onPaymentCardsComposed(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    .line 27
    return-void
.end method
