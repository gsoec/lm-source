.class Lcom/igg/sdk/service/IGGMobileDeviceService$4;
.super Ljava/lang/Object;
.source "IGGMobileDeviceService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGMobileDeviceService;->registerDevice(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGMobileDeviceService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGMobileDeviceService;Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGMobileDeviceService;

    .prologue
    .line 269
    iput-object p1, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$4;->this$0:Lcom/igg/sdk/service/IGGMobileDeviceService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$4;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;

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
    .line 273
    const-string v0, "IGGMobileDeviceService"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "registerDevice responseString:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 274
    iget-object v0, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$4;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;

    invoke-interface {v0, p1}, Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;->onDeviceRegistrationFinished(Lcom/igg/sdk/error/IGGError;)V

    .line 275
    return-void
.end method
