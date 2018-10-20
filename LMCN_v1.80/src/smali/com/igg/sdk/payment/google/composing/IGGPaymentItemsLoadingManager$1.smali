.class Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;
.super Ljava/lang/Object;
.source "IGGPaymentItemsLoadingManager.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadItemsInternal()V
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
    .line 75
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .prologue
    .line 78
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$000(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 79
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$100(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)V

    .line 112
    :goto_0
    return-void

    .line 81
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$700(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    move-result-object v0

    new-instance v1, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;

    invoke-direct {v1, p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1$1;-><init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;)V

    invoke-virtual {v0, v1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->loadItems(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;)V

    goto :goto_0
.end method
