.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$5;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->OpenGeTuiNotification()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .prologue
    .line 310
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$5;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 1

    .prologue
    .line 313
    invoke-static {}, Lcom/igg/iggsdkbusiness/GeTuiRegister;->sharedInstance()Lcom/igg/iggsdkbusiness/GeTuiRegister;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/GeTuiRegister;->init()V

    .line 314
    return-void
.end method
