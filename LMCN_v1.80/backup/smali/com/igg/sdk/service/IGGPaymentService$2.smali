.class Lcom/igg/sdk/service/IGGPaymentService$2;
.super Ljava/lang/Object;
.source "IGGPaymentService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGPaymentService;->loadItems(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGPaymentService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGPaymentService;

    .prologue
    .line 163
    iput-object p1, p0, Lcom/igg/sdk/service/IGGPaymentService$2;->this$0:Lcom/igg/sdk/service/IGGPaymentService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGPaymentService$2;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 3
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 166
    iget-object v0, p0, Lcom/igg/sdk/service/IGGPaymentService$2;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;

    if-eqz v0, :cond_0

    .line 167
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 168
    iget-object v0, p0, Lcom/igg/sdk/service/IGGPaymentService$2;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;

    const/4 v1, 0x0

    invoke-interface {v0, p1, v1}, Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;->onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;)V

    .line 176
    :cond_0
    :goto_0
    return-void

    .line 172
    :cond_1
    sget-object v0, Lcom/igg/sdk/service/IGGPaymentService;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "responseString:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 174
    iget-object v0, p0, Lcom/igg/sdk/service/IGGPaymentService$2;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;

    invoke-interface {v0, p1, p3}, Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;->onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;)V

    goto :goto_0
.end method
