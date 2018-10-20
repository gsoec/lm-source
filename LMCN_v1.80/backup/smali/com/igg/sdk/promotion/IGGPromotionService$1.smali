.class Lcom/igg/sdk/promotion/IGGPromotionService$1;
.super Lcom/igg/sdk/promotion/IGGPromotionService$InitilizationHandler;
.source "IGGPromotionService.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/promotion/IGGPromotionService;->initialize(Landroid/content/Context;Lcom/igg/sdk/promotion/listener/IGGInitializationListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/promotion/IGGPromotionService;

.field final synthetic val$listener:Lcom/igg/sdk/promotion/listener/IGGInitializationListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/promotion/IGGPromotionService;Lcom/igg/sdk/promotion/listener/IGGInitializationListener;)V
    .locals 1
    .param p1, "this$0"    # Lcom/igg/sdk/promotion/IGGPromotionService;

    .prologue
    .line 82
    iput-object p1, p0, Lcom/igg/sdk/promotion/IGGPromotionService$1;->this$0:Lcom/igg/sdk/promotion/IGGPromotionService;

    iput-object p2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$1;->val$listener:Lcom/igg/sdk/promotion/listener/IGGInitializationListener;

    const/4 v0, 0x0

    invoke-direct {p0, v0}, Lcom/igg/sdk/promotion/IGGPromotionService$InitilizationHandler;-><init>(Lcom/igg/sdk/promotion/IGGPromotionService$1;)V

    return-void
.end method


# virtual methods
.method public handleMessage(Landroid/os/Message;)V
    .locals 2
    .param p1, "msg"    # Landroid/os/Message;

    .prologue
    .line 85
    iget v0, p1, Landroid/os/Message;->what:I

    if-nez v0, :cond_0

    .line 86
    iget-object v1, p0, Lcom/igg/sdk/promotion/IGGPromotionService$1;->this$0:Lcom/igg/sdk/promotion/IGGPromotionService;

    iget-object v0, p1, Landroid/os/Message;->obj:Ljava/lang/Object;

    check-cast v0, Ljava/lang/String;

    invoke-static {v1, v0}, Lcom/igg/sdk/promotion/IGGPromotionService;->access$102(Lcom/igg/sdk/promotion/IGGPromotionService;Ljava/lang/String;)Ljava/lang/String;

    .line 89
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/promotion/IGGPromotionService$1;->val$listener:Lcom/igg/sdk/promotion/listener/IGGInitializationListener;

    iget-object v1, p0, Lcom/igg/sdk/promotion/IGGPromotionService$1;->this$0:Lcom/igg/sdk/promotion/IGGPromotionService;

    invoke-interface {v0, v1}, Lcom/igg/sdk/promotion/listener/IGGInitializationListener;->onInitializeFinished(Lcom/igg/sdk/promotion/IGGPromotionService;)V

    .line 90
    return-void
.end method
