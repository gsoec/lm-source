.class Lcom/rak24/androidimmersivemode/Main$3;
.super Ljava/lang/Object;
.source "Main.java"

# interfaces
.implements Landroid/view/View$OnSystemUiVisibilityChangeListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/rak24/androidimmersivemode/Main;->SetUIChangeListener(Landroid/view/View;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/rak24/androidimmersivemode/Main;

.field private final synthetic val$unityView:Landroid/view/View;


# direct methods
.method constructor <init>(Lcom/rak24/androidimmersivemode/Main;Landroid/view/View;)V
    .locals 0

    .prologue
    .line 1
    iput-object p1, p0, Lcom/rak24/androidimmersivemode/Main$3;->this$0:Lcom/rak24/androidimmersivemode/Main;

    iput-object p2, p0, Lcom/rak24/androidimmersivemode/Main$3;->val$unityView:Landroid/view/View;

    .line 142
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onSystemUiVisibilityChange(I)V
    .locals 1
    .param p1, "visibility"    # I

    .prologue
    .line 147
    and-int/lit8 v0, p1, 0x4

    if-nez v0, :cond_0

    .line 149
    iget-object v0, p0, Lcom/rak24/androidimmersivemode/Main$3;->val$unityView:Landroid/view/View;

    invoke-static {v0}, Lcom/rak24/androidimmersivemode/Main;->ImmersiveMode(Landroid/view/View;)V

    .line 151
    :cond_0
    return-void
.end method
