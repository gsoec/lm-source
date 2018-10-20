.class Lcom/igg/sdk/IGGAppProfile$1;
.super Ljava/lang/Object;
.source "IGGAppProfile.java"

# interfaces
.implements Lcom/igg/sdk/IGGAppProfile$FieldListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/IGGAppProfile;->updateLastLoginTime()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/IGGAppProfile;


# direct methods
.method constructor <init>(Lcom/igg/sdk/IGGAppProfile;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/IGGAppProfile;

    .prologue
    .line 84
    iput-object p1, p0, Lcom/igg/sdk/IGGAppProfile$1;->this$0:Lcom/igg/sdk/IGGAppProfile;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onAdded(Ljava/lang/String;)V
    .locals 3
    .param p1, "value"    # Ljava/lang/String;

    .prologue
    .line 92
    invoke-static {}, Lcom/igg/sdk/IGGNotificationCenter;->sharedInstance()Lcom/igg/sdk/IGGNotificationCenter;

    move-result-object v0

    new-instance v1, Lcom/igg/sdk/IGGNotification;

    const-string v2, "FIRST_LOGIN"

    invoke-direct {v1, v2, p0}, Lcom/igg/sdk/IGGNotification;-><init>(Ljava/lang/String;Ljava/lang/Object;)V

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGNotificationCenter;->postNotification(Lcom/igg/sdk/IGGNotification;)V

    .line 96
    return-void
.end method

.method public onUpdated(Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "oldValue"    # Ljava/lang/String;
    .param p2, "newValue"    # Ljava/lang/String;

    .prologue
    .line 88
    return-void
.end method
