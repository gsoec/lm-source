.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2$1;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Landroid/content/DialogInterface$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;->run()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;

.field final synthetic val$names:[Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;[Ljava/lang/String;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;

    .prologue
    .line 199
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2$1;->this$1:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2$1;->val$names:[Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/content/DialogInterface;I)V
    .locals 2
    .param p1, "dialog"    # Landroid/content/DialogInterface;
    .param p2, "which"    # I

    .prologue
    .line 203
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2$1;->val$names:[Ljava/lang/String;

    aget-object v0, v1, p2

    .line 204
    .local v0, "emailSelected":Ljava/lang/String;
    invoke-static {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 205
    invoke-static {}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->sharedInstance()Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    move-result-object v1

    .line 206
    invoke-virtual {v1, v0}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->bindingGoogle(Ljava/lang/String;)V

    .line 207
    return-void
.end method
