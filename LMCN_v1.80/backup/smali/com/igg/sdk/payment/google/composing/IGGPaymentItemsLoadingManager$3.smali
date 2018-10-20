.class Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$3;
.super Ljava/util/TimerTask;
.source "IGGPaymentItemsLoadingManager.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->retryLoad()Z
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

.field final synthetic val$timer:Ljava/util/Timer;


# direct methods
.method constructor <init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;Ljava/util/Timer;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 148
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$3;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    iput-object p2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$3;->val$timer:Ljava/util/Timer;

    invoke-direct {p0}, Ljava/util/TimerTask;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 1

    .prologue
    .line 151
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$3;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$800(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Ljava/util/concurrent/atomic/AtomicBoolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicBoolean;->get()Z

    move-result v0

    if-nez v0, :cond_0

    .line 152
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$3;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->access$900(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)V

    .line 154
    :cond_0
    invoke-virtual {p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$3;->cancel()Z

    .line 155
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$3;->val$timer:Ljava/util/Timer;

    invoke-virtual {v0}, Ljava/util/Timer;->cancel()V

    .line 156
    return-void
.end method
