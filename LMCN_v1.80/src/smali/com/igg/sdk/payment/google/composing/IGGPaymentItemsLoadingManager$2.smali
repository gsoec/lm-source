.class Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$2;
.super Ljava/lang/Object;
.source "IGGPaymentItemsLoadingManager.java"

# interfaces
.implements Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->composeIfNeed()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;


# direct methods
.method constructor <init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 121
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$2;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentCardsComposed(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
    .locals 3
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
    .line 124
    .local p2, "items":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 125
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$2;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$500(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 127
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$2;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$2;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$000(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->getIGGGameItems()Ljava/util/ArrayList;

    move-result-object v2

    invoke-static {v0, v1, v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$600(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    .line 132
    :cond_0
    :goto_0
    return-void

    .line 130
    :cond_1
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$2;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0, p1, p2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$600(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    goto :goto_0
.end method
