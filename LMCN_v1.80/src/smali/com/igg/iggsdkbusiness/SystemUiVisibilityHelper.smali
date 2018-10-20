.class public Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;
.super Ljava/lang/Object;
.source "SystemUiVisibilityHelper.java"


# static fields
.field private static instance:Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 10
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 11
    return-void
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;
    .locals 1

    .prologue
    .line 14
    sget-object v0, Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;->instance:Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;

    if-nez v0, :cond_0

    .line 15
    new-instance v0, Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;->instance:Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;

    .line 17
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;->instance:Lcom/igg/iggsdkbusiness/SystemUiVisibilityHelper;

    return-object v0
.end method


# virtual methods
.method public SetSystemUiVisibility(Landroid/app/Activity;)V
    .locals 2
    .param p1, "activity"    # Landroid/app/Activity;

    .prologue
    .line 21
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x13

    if-lt v0, v1, :cond_0

    .line 23
    invoke-virtual {p1}, Landroid/app/Activity;->getWindow()Landroid/view/Window;

    move-result-object v0

    invoke-virtual {v0}, Landroid/view/Window;->getDecorView()Landroid/view/View;

    move-result-object v0

    const/16 v1, 0x1706

    invoke-virtual {v0, v1}, Landroid/view/View;->setSystemUiVisibility(I)V

    .line 31
    :cond_0
    return-void
.end method
