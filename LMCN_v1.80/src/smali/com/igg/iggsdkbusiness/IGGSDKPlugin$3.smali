.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$3;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->OpenPushNotification()V
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
    .line 286
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$3;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 1

    .prologue
    .line 289
    invoke-static {}, Lcom/igg/iggsdkbusiness/GCMRegister;->sharedInstance()Lcom/igg/iggsdkbusiness/GCMRegister;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/GCMRegister;->init()V

    .line 290
    return-void
.end method
