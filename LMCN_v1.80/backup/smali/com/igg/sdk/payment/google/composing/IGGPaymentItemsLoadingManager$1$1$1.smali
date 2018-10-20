.class Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1$1;
.super Ljava/lang/Object;
.source "IGGPaymentItemsLoadingManager.java"

# interfaces
.implements Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->onPaymentCardsLoaded(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$2:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;


# direct methods
.method constructor <init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;)V
    .locals 0
    .param p1, "this$2"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;

    .prologue
    .line 87
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1$1;->this$2:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLoadCacheFinished(Ljava/util/List;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 90
    .local p1, "items":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1$1;->this$2:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;

    iget-object v0, v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    iget-object v0, v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$400(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 91
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1$1;->this$2:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;

    iget-object v0, v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;->this$1:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    iget-object v0, v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$400(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    move-result-object v0

    invoke-interface {v0, p1}, Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;->onLoadCachePaymentItemsFinished(Ljava/util/List;)V

    .line 93
    :cond_0
    return-void
.end method
