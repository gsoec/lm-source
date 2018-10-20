.class Lcom/igg/sdk/service/IGGMycardOrderInfoService$2;
.super Ljava/lang/Object;
.source "IGGMycardOrderInfoService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGMycardOrderInfoService;->getOrderNumber(Ljava/lang/String;IILjava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGMycardOrderInfoService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGMycardOrderInfoService;Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGMycardOrderInfoService;

    .prologue
    .line 96
    iput-object p1, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService$2;->this$0:Lcom/igg/sdk/service/IGGMycardOrderInfoService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService$2;->val$listener:Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentItemsOrdersSerialFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;)V
    .locals 1
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseString"    # Ljava/lang/String;

    .prologue
    .line 100
    if-nez p2, :cond_0

    .line 101
    const-string p2, ""

    .line 104
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService$2;->val$listener:Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;

    invoke-interface {v0, p2}, Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;->onPaymentItemsOrdersSerialFinished(Ljava/lang/String;)V

    .line 105
    return-void
.end method
