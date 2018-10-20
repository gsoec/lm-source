.class Lcom/igg/sdk/service/MycardOrderInfoService$2;
.super Ljava/lang/Object;
.source "MycardOrderInfoService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/MycardOrderInfoService;->getOrderNumber(Ljava/lang/String;IILjava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/MycardOrderInfoService;

.field final synthetic val$listener:Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/MycardOrderInfoService;Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/MycardOrderInfoService;

    .prologue
    .line 93
    iput-object p1, p0, Lcom/igg/sdk/service/MycardOrderInfoService$2;->this$0:Lcom/igg/sdk/service/MycardOrderInfoService;

    iput-object p2, p0, Lcom/igg/sdk/service/MycardOrderInfoService$2;->val$listener:Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentItemsOrdersSerialFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;)V
    .locals 1
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseString"    # Ljava/lang/String;

    .prologue
    .line 97
    if-nez p2, :cond_0

    .line 98
    const-string p2, ""

    .line 101
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/service/MycardOrderInfoService$2;->val$listener:Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;

    invoke-interface {v0, p2}, Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;->onPaymentItemsOrdersSerialFinished(Ljava/lang/String;)V

    .line 102
    return-void
.end method
