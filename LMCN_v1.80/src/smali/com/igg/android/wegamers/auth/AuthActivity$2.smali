.class Lcom/igg/android/wegamers/auth/AuthActivity$2;
.super Ljava/lang/Object;
.source "AuthActivity.java"

# interfaces
.implements Lcom/igg/android/wegamers/auth/IAuthResponse;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/android/wegamers/auth/AuthActivity;->initData()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/android/wegamers/auth/AuthActivity;


# direct methods
.method constructor <init>(Lcom/igg/android/wegamers/auth/AuthActivity;)V
    .locals 0

    .prologue
    .line 1
    iput-object p1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    .line 70
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static synthetic access$0(Lcom/igg/android/wegamers/auth/AuthActivity$2;)Lcom/igg/android/wegamers/auth/AuthActivity;
    .locals 1

    .prologue
    .line 70
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    return-object v0
.end method


# virtual methods
.method public onComplete(ILcom/igg/android/wegamers/auth/AuthInfo;)V
    .locals 2
    .param p1, "iRet"    # I
    .param p2, "authInfo"    # Lcom/igg/android/wegamers/auth/AuthInfo;

    .prologue
    .line 74
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    new-instance v1, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;

    invoke-direct {v1, p0, p1, p2}, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;-><init>(Lcom/igg/android/wegamers/auth/AuthActivity$2;ILcom/igg/android/wegamers/auth/AuthInfo;)V

    invoke-virtual {v0, v1}, Lcom/igg/android/wegamers/auth/AuthActivity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 96
    return-void
.end method
