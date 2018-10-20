.class Lcom/igg/sdk/service/IGGMobileDeviceService$2;
.super Ljava/lang/Object;
.source "IGGMobileDeviceService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGMobileDeviceService;->updateUser(Ljava/lang/String;Lcom/igg/sdk/service/IGGMobileDeviceService$UpdateUserListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGMobileDeviceService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$UpdateUserListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGMobileDeviceService;Lcom/igg/sdk/service/IGGMobileDeviceService$UpdateUserListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGMobileDeviceService;

    .prologue
    .line 108
    iput-object p1, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$2;->this$0:Lcom/igg/sdk/service/IGGMobileDeviceService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$2;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$UpdateUserListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 1
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 112
    iget-object v0, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$2;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$UpdateUserListener;

    invoke-interface {v0, p1}, Lcom/igg/sdk/service/IGGMobileDeviceService$UpdateUserListener;->onUpdateUserListenerFinished(Lcom/igg/sdk/error/IGGError;)V

    .line 113
    return-void
.end method
