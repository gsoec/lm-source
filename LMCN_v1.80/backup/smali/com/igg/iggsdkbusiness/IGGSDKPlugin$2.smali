.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LinkGoogleAccount()V
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
    .line 190
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 3

    .prologue
    .line 193
    invoke-static {}, Lcom/igg/sdk/account/GooglePlay;->getLocalRegisteredEmails()[Ljava/lang/String;

    move-result-object v0

    .line 194
    .local v0, "names":[Ljava/lang/String;
    array-length v1, v0

    if-nez v1, :cond_0

    .line 195
    const-string v1, "names.length == 0\u3002\u3002\u3002\u3002\uff01"

    invoke-static {v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 209
    :goto_0
    return-void

    .line 198
    :cond_0
    new-instance v1, Landroid/app/AlertDialog$Builder;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v2

    invoke-direct {v1, v2}, Landroid/app/AlertDialog$Builder;-><init>(Landroid/content/Context;)V

    new-instance v2, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2$1;

    invoke-direct {v2, p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2$1;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;[Ljava/lang/String;)V

    .line 199
    invoke-virtual {v1, v0, v2}, Landroid/app/AlertDialog$Builder;->setItems([Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v1

    .line 208
    invoke-virtual {v1}, Landroid/app/AlertDialog$Builder;->create()Landroid/app/AlertDialog;

    move-result-object v1

    invoke-virtual {v1}, Landroid/app/AlertDialog;->show()V

    goto :goto_0
.end method
